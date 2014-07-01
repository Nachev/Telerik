/// <reference path="alien.ts" />
/// <reference path="../interfaces/ihumanoid.ts" />
module Creatures {
    "use strict";
    export class Humanoid extends Alien implements IHumanoid {
        constructor(initialCreatureType: CreatureType) {
            super(initialCreatureType);
        }

        swim(): void { }

        takeGun(): void { }

        driveVehicle(): void { }
    }
} 