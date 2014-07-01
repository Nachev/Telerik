var Creatures;
(function (Creatures) {
    "use strict";
    (function (CreatureType) {
        CreatureType[CreatureType["Worker"] = 0] = "Worker";
        CreatureType[CreatureType["Fighter"] = 1] = "Fighter";
        CreatureType[CreatureType["Scientist"] = 2] = "Scientist";
    })(Creatures.CreatureType || (Creatures.CreatureType = {}));
    var CreatureType = Creatures.CreatureType;
})(Creatures || (Creatures = {}));
//# sourceMappingURL=CreatureType.js.map
