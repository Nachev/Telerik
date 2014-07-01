/// <reference path="../enumerations/vehicletype.ts" />
module Vehicles {
    "use strict";
    export interface IVehicle {
        vehicleType: VehicleType;
        move(): void;
        shoot(): void;
    }
} 