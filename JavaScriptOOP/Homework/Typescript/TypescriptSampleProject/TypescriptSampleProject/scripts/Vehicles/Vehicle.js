/// <reference path="../enumerations/vehicletype.ts" />
var Vehicles;
(function (Vehicles) {
    "use strict";
    var Vehicle = (function () {
        function Vehicle(initialVehicleType) {
            this._vehicleType = initialVehicleType;
        }
        Object.defineProperty(Vehicle.prototype, "vehicleType", {
            get: function () {
                return this._vehicleType;
            },
            enumerable: true,
            configurable: true
        });

        Vehicle.prototype.move = function () {
        };

        Vehicle.prototype.shoot = function () {
            if (this._vehicleType === 1 /* Cargo */) {
                throw new Error("Cargo vehicles cannot shoot");
            }
        };
        return Vehicle;
    })();
    Vehicles.Vehicle = Vehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=Vehicle.js.map
