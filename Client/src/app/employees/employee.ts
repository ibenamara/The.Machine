export class IEmployee {
    Id : number;
    Name : string;
    CreationDAte : Date;
    Preference : IEmployeePrefence
}

export class IEmployeePrefence {
    Id : number;
    UsePersonalMug : boolean;
    SugarQuantity : number ;
    Drink : IDrink
}

export class IDrink {
    Id : number;
    Name : string;
    Description : string;
}