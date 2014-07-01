var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="creature.ts" />
var Creatures;
(function (Creatures) {
    "use strict";
    var Alien = (function (_super) {
        __extends(Alien, _super);
        function Alien(initialCreatureType) {
            _super.call(this, initialCreatureType);
        }
        Alien.prototype.readMind = function () {
        };
        return Alien;
    })(Creatures.Creature);
    Creatures.Alien = Alien;
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Alien.js.map
