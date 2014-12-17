var Category = require('mongoose').model('Category');

module.exports = {
  create: function(category, callback) {
    Category.create(category, callback);
  },
  seedInitialCategories: function() {
    Category.find({}).exec(function(err, collection) {
      if (collection.length === 0) {
        Category.create({
          name: "team building"
        });
        Category.create({
          name: "party"
        });
        Category.create({
          name: "coding"
        });

        console.log("Categories added to the database.");
      }
    });
  },
};
