/// <reference path="creature.ts" />
module Creatures {
    "use strict";
    export class Alien extends Creature {
        constructor(initialCreatureType: CreatureType) {
            super(initialCreatureType);
        }

        readMind(): void { }
    }
}