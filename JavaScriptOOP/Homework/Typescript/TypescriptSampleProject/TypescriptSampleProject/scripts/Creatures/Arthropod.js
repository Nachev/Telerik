var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
/// <reference path="alien.ts" />
var Creatures;
(function (Creatures) {
    "use strict";
    var Arthropod = (function (_super) {
        __extends(Arthropod, _super);
        function Arthropod(initialCreatureType) {
            _super.call(this, initialCreatureType);
        }
        return Arthropod;
    })(Creatures.Alien);
})(Creatures || (Creatures = {}));
//# sourceMappingURL=Arthropod.js.map
