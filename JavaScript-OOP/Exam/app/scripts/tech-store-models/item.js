define(function () {
    var Item = (function () {
        function validateType(type) {
            if (type === 'accessory' || type === 'smart-phone' ||
                type === 'notebook' || type === 'pc' || type === 'tablet') {
                return;
            } else {
                throw {
                    message: "Invalid type for stock item!"
                };
            }
        }

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

        function validatePrice(price) {
            if ((typeof price).toLowerCase() === 'number') {
                return;
            } else {
                throw {
                    message: "Invalid price for stock item!"
                };
            }
        }

        var Item = function (type, name, price) {
            validateType(type);
            validateName(name);
            validatePrice(price);
            this._type = type;
            this._name = name;
            this._price = price;
        };

        Item.prototype.getName = function () {
            return this._name;
        };

        Item.prototype.getType = function () {
            return this._type;
        };

        Item.prototype.getPrice = function () {
            return this._price;
        };

        return Item;
    }());

    return Item;
});