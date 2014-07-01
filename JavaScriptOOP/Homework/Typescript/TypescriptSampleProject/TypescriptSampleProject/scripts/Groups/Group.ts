module Groups {
    "use strict";
    export class Group<T> {
        private _container: T[];
        private _name: string;

        constructor(initialName: string) {
            this._name = initialName;
        }

        add (gameAsset: T): void {
            this._container.push(gameAsset);
        }

        remove (gameAsset: T): T {
            var indexToRemove: number = this._container.indexOf(gameAsset);
            if (indexToRemove < 0) {
                throw new Error("No such asset in this group");
            }

            this._container[indexToRemove] = this._container[this._container.length - 1];
            this._container.pop();

            return gameAsset;
        }
    }
} 