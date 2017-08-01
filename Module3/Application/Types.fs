module Types

open System


type [<Measure>] EUR
type [<Measure>] USD

type PersonalDetails = {
    FirstName : string
    LastName : string
    DateOfBirth : DateTime
}

type Notifications =
    | NoNotifications
    | ReceiveNotifications of receiveDeals:bool * receiveAlerts:bool

type Customer = {
    Id: int
    IsVip: bool
    Credit: decimal<USD>
    PersonalDetails: PersonalDetails option
    Notifications: Notifications
}

//1.1. Go to the Module3/Application, open Types.fs and create the following types (above the existing Customer
//type):
// A record called “PersonalDetails” with the following fields:
//o FirstName: string
//o LastName: string
//o DateOfBirth: DateTime
// Two units of measure: “EUR” and “USD”.
// A discriminated union called “Notifications” with the following cases:
//o NoNotifications
//o ReceiveNotification of receiveDeals: bool * receiveAlerts: bool
//Then add the following new fields to the Customer:
// PersonalDetails: PersonalDetails option
// Notifications: Notifications
//Finally update the Credit field to use the decimal<USD> type




