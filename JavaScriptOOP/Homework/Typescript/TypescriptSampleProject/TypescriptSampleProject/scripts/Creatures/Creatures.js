var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Creatures;
(function (Creatures) {
    "use strict";
    var CreatureType;
    (function (CreatureType) {
        CreatureType[CreatureType["Worker"] = 0] = "Worker";
        CreatureType[CreatureType["Fighter"] = 1] = "Fighter";
        CreatureType[CreatureType["Scientist"] = 2] = "Scientist";
    })(CreatureType || (CreatureType = {}));

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
        return Creature;
    })();

    var Human = (function (_super) {
        __extends(Human, _super);
        function Human(initialCreatureType) {
            _super.call(this, initialCreatureType);
        }
        return Human;
    })(Creature);
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Creatures.js.map
