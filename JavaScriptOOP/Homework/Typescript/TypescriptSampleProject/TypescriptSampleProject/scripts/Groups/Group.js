var Groups;
(function (Groups) {
    "use strict";
    var Group = (function () {
        function Group(initialName) {
            this._name = initialName;
        }
        Group.prototype.add = function (gameAsset) {
            this._container.push(gameAsset);
        };

        Group.prototype.remove = function (gameAsset) {
            var indexToRemove = this._container.indexOf(gameAsset);
            if (indexToRemove < 0) {
                throw new Error("No such asset in this group");
            }

            this._container[indexToRemove] = this._container[this._container.length - 1];
            this._container.pop();

            return gameAsset;
        };
        return Group;
    })();
    Groups.Group = Group;
})(Groups || (Groups = {}));
//# sourceMappingURL=Group.js.map
