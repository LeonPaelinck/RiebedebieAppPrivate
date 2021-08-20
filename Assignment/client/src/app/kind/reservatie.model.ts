interface ReservationJson {
    id: number;
    date: string;
    earlier: string; //boolean
    later: string; //boolean
    childId: number;
    pricePerDay: string;
    afterHoursPrice: string;
  }

export class Reservatie {
    private _id: number;
    private _afterHoursPrice: number;
    private _pricePerDay: number;
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
      reservatie.afterHoursPrice = Number(json.afterHoursPrice);
      reservatie.pricePerDay = Number(json.pricePerDay);
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

    public get price(): number
    {
        let price: number = this.pricePerDay;
        if (this.earlier) price += this.afterHoursPrice;
        if (this.later) price += this.afterHoursPrice;
        return price;
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
    public get pricePerDay(): number {
      return this._pricePerDay;
    }
    public set pricePerDay(value: number) {
      this._pricePerDay = value;
    }
    public get afterHoursPrice(): number {
      return this._afterHoursPrice;
    }
    public set afterHoursPrice(value: number) {
      this._afterHoursPrice = value;
    }
  }