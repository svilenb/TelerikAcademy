define(['tech-store-models/item'], function (Item) {
    var Store = (function () {
        function validateName(name) {
            if ((typeof name).toLowerCase() === 'string' &&
                name.length >= 6 && name.length <= 40) {
                return;
            } else {
                throw {
                    message: "Invalid name for stock item!"
                };
            }
        }

        function orderByAscending(firstItem, secondItem) {
            if (secondItem > firstItem) {
                return -1;
            } else if (secondItem === firstItem) {
                return 0;
            } else if (secondItem < firstItem) {
                return 1;
            }
        }

        function orderAlphabetically(firstItem, secondItem) {
            var firstItemLowerCase = firstItem.toLowerCase(),
                secondItemLowerCase = secondItem.toLowerCase();

            if (secondItemLowerCase > firstItemLowerCase) {
                return -1;
            } else if (secondItemLowerCase === firstItemLowerCase) {
                return 0;
            } else if (secondItemLowerCase < firstItemLowerCase) {
                return 1;
            }
        }

        var Store = function (name) {
            validateName(name);
            this._name = name;
            this._items = [];
        };

        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw {
                    message: "Store must contain only items of type Item!"
                };
            }

            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            var result = this._items.slice();

            result.sort(function (firstItem, secondItem) {
                return orderAlphabetically(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        Store.prototype.getSmartPhones = function () {
            var result = this._items.filter(function (element) {
                return (element.getType() === 'smart-phone');
            });

            result.sort(function (firstItem, secondItem) {
                return orderAlphabetically(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        Store.prototype.getMobiles = function () {
            var result = this._items.filter(function (element) {
                return (element.getType() === 'smart-phone' ||
                    element.getType() === 'tablet');
            });

            result.sort(function (firstItem, secondItem) {
                return orderAlphabetically(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        Store.prototype.getComputers = function () {
            var result = this._items.filter(function (element) {
                return (element.getType() === 'pc' ||
                    element.getType() === 'notebook');
            });

            result.sort(function (firstItem, secondItem) {
                return orderAlphabetically(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        Store.prototype.filterItemsByType = function (filterType) {
            var result = this._items.filter(function (element) {
                return (element.getType() === filterType);
            });

            result.sort(function (firstItem, secondItem) {
                return orderAlphabetically(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        Store.prototype.filterItemsByPrice = function (options) {
            var minPrice,
                maxPrice;

            if (!options) {
                minPrice = 0;
                maxPrice = Infinity;
            } else {
                minPrice = options.min || 0;
                maxPrice = options.max || Infinity;
            }

            var result = this._items.filter(function (element) {
                return (element.getPrice() >= minPrice && element.getPrice() <= maxPrice);
            });

            result.sort(function (firstItem, secondItem) {
                return orderByAscending(firstItem.getPrice(), secondItem.getPrice());
            });

            return result;
        };

        Store.prototype.countItemsByType = function () {
            var result = [],
                i,
                len,
                item;

            for (i = 0, len = this._items.length; i < len; i++) {
                item = this._items[i];

                if (result[item.getType()] === undefined) {
                    result[item.getType()] = 1;
                } else {
                    result[item.getType()] += 1;
                }
            }

            return result;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var i,
                len,
                item,
                result = [];

            for (i = 0, len = this._items.length; i < len; i++) {
                item = this._items[i];

                if (item.getName().toLocaleLowerCase().indexOf(partOfName.toLowerCase()) !== -1) {
                    result.push(item);
                }
            }

            result.sort(function (firstItem, secondItem) {
                return orderByAscending(firstItem.getName(), secondItem.getName());
            });

            return result;
        };

        return Store;
    }());

    return Store;
});