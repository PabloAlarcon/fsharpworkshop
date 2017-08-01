module Functions

open Types
open System

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M<USD> }
    else { customer with Credit = customer.Credit + 50M<USD> }

let increaseCreditUsingVip = increaseCredit (fun c -> c.IsVip)

let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip


//Create a function called “isAdult” in Module3/Application/Functions.fs that
// Receives a customer as parameter
// Returns false if the PersonalDetails are not defined (None)
// Returns true if the customer is 18 years of age or older, or false otherwise

let isAdult customer = 
    match customer.PersonalDetails with
    | Some details -> details.DateOfBirth.AddYears 18 <= DateTime.Now.Date
    | None -> false

//    4.1. Create a function called “getAlert” in Module3/Application/Functions.fs that
// Receives a customer as parameter
// Returns “Alert for customer [Id]” if the customer allowed alerts or returns an empty string otherwise.


let getAlert customer = 
    match customer.Notifications with
    //REMARKS : Uhm, with named tuples parameters we use ';' separators but ',' for unnamed!?
    //| ReceiveNotifications (receiveDeals = _; receiveAlerts = true) -> sprintf "Alert for customer %i " customer.Id
    | ReceiveNotifications ( _, true) -> sprintf "Alert for customer %i" customer.Id
    | _ -> String.Empty