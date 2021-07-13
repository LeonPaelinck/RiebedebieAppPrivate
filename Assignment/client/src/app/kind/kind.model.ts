interface ChildJson {
  id: number;
  lastName: string;
  firstName: string;
  birthDate: string;
}

enum LeeftijdsCategorie {
  Peuter = "Te jong",
  Kleuter = 'Kleuter',
  Kind = 'Kind',
  Tiener = 'Tiener',
  Animator = 'Te oud'
}

export class Kind {
  private _id: number;
  constructor(
      private _lastName: string,
      private _firstName: string,
      private _birthDate: Date
    ) {}

  static fromJSON(json: ChildJson): Kind {
    const kind = new Kind(json.lastName, json.firstName, new Date(json.birthDate));
    kind.id = json.id;
    return kind;
  }

   toJSON (): ChildJson {
   return <ChildJson> {
     lastName: this.lastName,
     firstName: this.firstName,
     birthDate: this.birthDate.toDateString()
   };
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
  public get leeftijdsCategorie(): LeeftijdsCategorie {
      if(this.leeftijd < 3)
        return LeeftijdsCategorie.Peuter;
      else if(this.leeftijd < 6)
        return LeeftijdsCategorie.Kleuter;
      else if(this.leeftijd < 12)
        return LeeftijdsCategorie.Kind;
      else if(this.leeftijd < 16)
        return LeeftijdsCategorie.Tiener;
      //else 
        return LeeftijdsCategorie.Animator;
  }
 
  public get leeftijd(): number {
    return new Date().getFullYear() - this.birthDate.getFullYear(); //wordt berekend wanneer opgevraagd zodat het automatisch wordt aangepast naar elke dag
  }

  public get id(): number {
    return this._id;
  }
  public set id(value: number) {
    this._id = value;
  }
  
}
