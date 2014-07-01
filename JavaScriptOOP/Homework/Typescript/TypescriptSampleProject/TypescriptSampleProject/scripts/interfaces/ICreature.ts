/// <reference path="../enumerations/CreatureType.ts" />
module Creatures {
    "use strict";
    export interface ICreature {
        creatureType: CreatureType;

        move(): void;
        shoot(): void;
        hit(): void;
    }
}