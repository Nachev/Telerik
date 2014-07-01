/// <reference path="../interfaces/icreature.ts" />
var Creatures;
(function (Creatures) {
    "use strict";
    var Creature = (function () {
        function Creature(initialCreatureType) {
            this._creatureType = initialCreatureType;
        }
        Object.defineProperty(Creature.prototype, "creatureType", {
            get: function () {
                return this._creatureType;
            },
            enumerable: true,
            configurable: true
        });

        Creature.prototype.move = function () {
        };

        Creature.prototype.shoot = function () {
        };

        Creature.prototype.hit = function () {
        };
        return Creature;
    })();
    Creatures.Creature = Creature;
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Creature.js.map
