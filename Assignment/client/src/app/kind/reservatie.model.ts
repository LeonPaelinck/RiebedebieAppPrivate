interface ReservationJson {
    id: number;
    date: string;
    earlier: string; //boolean
    later: string; //boolean
    childId: number;
  }

export class Reservatie {
    private _id: number;
    constructor(
        private _date: Date,
        private _later: boolean,
        private _earlier: boolean,
        private _childId: number
      ) {
      }
  
    static fromJSON(json: ReservationJson): Reservatie {
      const reservatie = new Reservatie(new Date(json.date), JSON.parse(json.earlier), JSON.parse(json.later), json.childId);
      reservatie.id = json.id;
      return reservatie;
    }
  
     toJSON (): ReservationJson {
     return <ReservationJson> {
      date: this.date.toDateString(),
       earlier: String(this.earlier),
       later: String(this.later),
       childId: this.childId
     };
   }
    public get date(): Date {
      return this._date;
    }
    public set date(value: Date) {
      this._date = value;
    }
    public get earlier(): boolean {
      return this._earlier;
    }
    public set earlier(value: boolean) {
      this._earlier = value;
    }
    public get later(): boolean {
      return this._later;
    }
    public set later(value: boolean) {
      this._later = value;
    }
    public get id(): number {
        return this._id;
      }
    public set id(value: number) {
      this._id = value;
    }
    public get childId(): number {
      return this._childId;
    }
    public set childId(value: number) {
      this._id = value;
    }
  }