/// <reference path="../interfaces/icreature.ts" />
module Creatures {
    "use strict";
    export class Creature implements ICreature {
        private _creatureType: CreatureType;

        constructor(initialCreatureType: CreatureType) {
            this._creatureType = initialCreatureType;
        }

        get creatureType(): CreatureType {
            return this._creatureType;
        }

        move(): void { }

        shoot(): void { }

        hit(): void { }
    }
} 