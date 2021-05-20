interface ReservationJson {
    id: number;
    earlier: string;
    later: string;
    date: string;
  }

export class Reservatie {
    private _id: number;
    constructor(
        private _date: Date,
        private _later: boolean,
        private _earlier: boolean
      ) {
      }
  
    static fromJSON(json: ReservationJson): Reservatie {
      const reservatie = new Reservatie(new Date(json.date), JSON.parse(json.earlier), JSON.parse(json.later));
      reservatie.id = json.id;
      return reservatie;
    }
  
     toJSON (): ReservationJson {
     return <ReservationJson> {
       earlier: String(this.earlier),
       later: String(this.later),
       date: this.date.toDateString()
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
  }