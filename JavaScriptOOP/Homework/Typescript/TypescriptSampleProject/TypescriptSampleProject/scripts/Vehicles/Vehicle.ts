/// <reference path="../enumerations/vehicletype.ts" />
module Vehicles {
    "use strict";
    export class Vehicle implements IVehicle {
        private _vehicleType: VehicleType;

        constructor(initialVehicleType: VehicleType) {
            this._vehicleType = initialVehicleType;
        }

        get vehicleType(): VehicleType {
            return this._vehicleType;
        }

        move(): void { }

        shoot(): void {
            if (this._vehicleType === VehicleType.Cargo) {
                throw new Error("Cargo vehicles cannot shoot");
            }
        }
    }
} 