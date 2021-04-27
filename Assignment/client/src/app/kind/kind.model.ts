interface ChildJson {
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

  constructor(
      private _lastName: string,
      private _firstName: string,
      private _birthDate: Date
    ) {
      this.leeftijd =  new Date().getFullYear() - this.birthDate.getFullYear();
      if(this.leeftijd < 3)
        this.leeftijdsCategorie = LeeftijdsCategorie.Peuter;
      else if(this.leeftijd < 6)
        this.leeftijdsCategorie = LeeftijdsCategorie.Kleuter;
      else if(this.leeftijd < 12)
        this.leeftijdsCategorie = LeeftijdsCategorie.Kind;
      else if(this.leeftijd < 16)
        this.leeftijdsCategorie = LeeftijdsCategorie.Tiener;
      else 
        this.leeftijdsCategorie = LeeftijdsCategorie.Animator;
    }

  private _leeftijd: number;

  private _leeftijdsCategorie: LeeftijdsCategorie;

  private _id: number;

  static fromJSON(json: ChildJson): Kind {
    const kind = new Kind(json.lastName, json.firstName, new Date(json.birthDate));
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
    return this._leeftijdsCategorie;
  }
  public set leeftijdsCategorie(value: LeeftijdsCategorie) {
    this._leeftijdsCategorie = value;
  }
  public get leeftijd(): number {
    return this._leeftijd;
  }
  public set leeftijd(value: number) {
    this._leeftijd = value;
  }
  public get id(): number {
    return this.id;
  }
  public set id(value: number) {
    this.id = value;
  }
  
}
