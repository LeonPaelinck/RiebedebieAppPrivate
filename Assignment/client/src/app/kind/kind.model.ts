interface KindJson {
  lastName: string;
  firstName: string;
  birthDate: string;
}
export class Kind {

    constructor(
        private _lastName: string,
        private _firstName: string,
        private _birthDate: Date
      ) {}

  static fromJSON(json: KindJson): Kind {
    const kind = new Kind(json.lastName, json.firstName, new Date(json.birthDate));
    return kind;
  }

  public get birthDate(): Date {
    return this._birthDate;
  }
  public set birthDate(value: Date) {
    this._birthDate = value;
  }
  public get firstName(): string {
    return this._firstName;
  }
  public set firstName(value: string) {
    this._firstName = value;
  }
  public get lastName(): string {
    return this._lastName;
  }
  public set lastName(value: string) {
    this._lastName = value;
  }
}
