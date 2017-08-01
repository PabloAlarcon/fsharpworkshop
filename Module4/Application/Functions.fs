module Functions

open Types
open System
open FSharp.Data

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer


type PurchaseData = JsonProvider<"Data.json">

let getPurchases customer =
    let purchases = PurchaseData.Load("Data.json")
    let avgPurchases = purchases
                       |> Seq.filter(fun p -> p.CustomerId = customer.Id)
                       |> Seq.collect( fun p -> p.PurchasesByMonth )
                       |> Seq.average

    (customer, avgPurchases)


let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M<USD> }
    else { customer with Credit = customer.Credit + 50M<USD> }

let increaseCreditUsingVip = increaseCredit (fun c -> c.IsVip)

let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip

let isAdult customer =
    match customer.PersonalDetails with
    | None -> false
    | Some d -> d.DateOfBirth.AddYears 18 <= DateTime.Now.Date

let getAlert customer =
    match customer.Notifications  with
    | ReceiveNotifications(receiveDeals = _; receiveAlerts = true) ->
        sprintf "Alert for customer %i" customer.Id
    | _ -> ""

let getCustomer id =
    let customers = [
        { Id = 1; IsVip = false; Credit = 0m<USD>; PersonalDetails = Some { FirstName = "John"; LastName = "Doe"; DateOfBirth = DateTime(1980, 1, 1) }; Notifications = NoNotifications }
        { Id = 2; IsVip = false; Credit = 10m<USD>; PersonalDetails = None; Notifications = ReceiveNotifications(true, true) }
        { Id = 3; IsVip = false; Credit = 30m<USD>; PersonalDetails = Some { FirstName = "Jane"; LastName = "Jones"; DateOfBirth = DateTime(2010, 2, 2) }; Notifications = ReceiveNotifications(true, false) }
        { Id = 4; IsVip = true;  Credit = 50m<USD>; PersonalDetails = Some { FirstName = "Joe"; LastName = "Smith"; DateOfBirth = DateTime(1986, 3, 3) }; Notifications = ReceiveNotifications(false, true) }
    ]
    customers
    |> List.find (fun c -> c.Id = id)



//    Go to the Module4/Application, open Functions.fs and change the “getPurchases” function so that:
// Uses the JsonProvider with the Data.json file (both as schema and data)
// Filters the customer by its id
// Collects the PurchasesByMonth field
// Calculates the purchases’ average
// Returns a tuple with the customer and the purchases’ average

