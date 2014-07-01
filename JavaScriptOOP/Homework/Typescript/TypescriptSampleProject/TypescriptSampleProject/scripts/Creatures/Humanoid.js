var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="alien.ts" />
/// <reference path="../interfaces/ihumanoid.ts" />
var Creatures;
(function (Creatures) {
    "use strict";
    var Humanoid = (function (_super) {
        __extends(Humanoid, _super);
        function Humanoid(initialCreatureType) {
            _super.call(this, initialCreatureType);
        }
        Humanoid.prototype.swim = function () {
        };

        Humanoid.prototype.takeGun = function () {
        };

        Humanoid.prototype.driveVehicle = function () {
        };
        return Humanoid;
    })(Creatures.Alien);
    Creatures.Humanoid = Humanoid;
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Humanoid.js.map
