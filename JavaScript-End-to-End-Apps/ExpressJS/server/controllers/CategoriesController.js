var mongoose = require('mongoose');
var Category = mongoose.model("Category");

module.exports = {
    createCategory: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var newCategory = req.body;

        if (!isAdmin) {
            res.status(400);
            return   res.send({ reason: 'You do not have permissions!' });
        }

        if (!newCategory.name) {
            res.status(400);
            res.send({ reason: "Category name is required!" });
            return;
        }

        Category.find({ name: newCategory.name }).exec(function (err, categories) {
            if (err) {
                console.log('Category could not be loaded: ' + err);
                res.status('500');
                return res.send('Category could not be loaded');
            }

            if (categories.length !== 0) {
                res.status('400');
                res.send('Category already exists');
                return;
            }

            Category.create(newCategory, function (err, category) {
                if (err) {
                    console.log('Failed to create new category: ' + err);
                    res.status(400);
                    res.send({ reason: "Failed to add category!" });
                    return;
                }

                res.status(201);
                res.location('/categories/'+category._id);
                res.send({
                    id: category._id,
                    name: category.name
                });
            });
        });
    },

    updateCategory: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var updatedCategory = req.body;

        if (!isAdmin) {
            res.status(400);
            return res.send({ reason: 'You do not have permissions!' });
        }

        if (!updatedCategory.name) {
            res.status(400);
            return res.send({ reason: "Name is missing!" });
        }

        Category.update({ _id: req.params.id }, updatedCategory, function (err) {
            if (err) {
                console.log('Categories could not be updated: ' + err);
                res.status('500');
                return res.send('Categories could not be updated');
            }

            res.end();
        })
    },

    getAllCategories: function (req, res) {
        var ascDesc = 1;

        if (req.query.desc == "true") {
            ascDesc = -1;
        }

        Category.find({})
            .select("name _id")
            .sort({ "name": ascDesc })
            .exec(function (err, collection) {
                if (err) {
                    console.log('Categories could not be loaded: ' + err);
                    res.status('500');
                    res.send('Categories could not be loaded');
                    return;
                }

                res.send(collection);
            })
    },

    getCategoryById: function (req, res) {
        Category.findOne({ _id: req.params.id })
            .select('name')
            .exec(function (err, category) {
                if (err) {
                    console.log('Category could not be loaded: ' + err);
                    res.status('500');
                    res.send('Category could not be loaded');
                    return;
                }

                if (category === null) {
                    res.status('400');
                    res.send("There no such category");
                    return;
                }

                res.send(category);
            })
    }
};