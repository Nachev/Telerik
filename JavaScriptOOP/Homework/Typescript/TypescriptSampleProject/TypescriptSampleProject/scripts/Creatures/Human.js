var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="creature.ts" />
/// <reference path="../interfaces/ihumanoid.ts" />
var Creatures;
(function (Creatures) {
    "use strict";
    var Human = (function (_super) {
        __extends(Human, _super);
        function Human(initialCreatureType) {
            _super.call(this, initialCreatureType);
        }
        Human.prototype.swim = function () {
        };

        Human.prototype.takeGun = function () {
        };

        Human.prototype.driveVehicle = function () {
        };
        Human.movementSpeed = 20;
        return Human;
    })(Creatures.Creature);
    Creatures.Human = Human;
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Human.js.map
