/// <reference path="creature.ts" />
/// <reference path="../interfaces/ihumanoid.ts" />
module Creatures {
    "use strict";
    export class Human extends Creature implements IHumanoid {
        private static movementSpeed = 20;

        constructor(initialCreatureType: CreatureType) {
            super(initialCreatureType);
        }

        swim(): void { }

        takeGun(): void { }

        driveVehicle(): void { }
    }
}