var Vehicles;
(function (Vehicles) {
    "use strict";
    (function (VehicleType) {
        VehicleType[VehicleType["Battle"] = 0] = "Battle";
        VehicleType[VehicleType["Cargo"] = 1] = "Cargo";
    })(Vehicles.VehicleType || (Vehicles.VehicleType = {}));
    var VehicleType = Vehicles.VehicleType;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=VehicleType.js.map
