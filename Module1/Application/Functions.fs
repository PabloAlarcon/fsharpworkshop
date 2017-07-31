module Functions

open Types

let tryPromoteToVip purchases =
    //Desconstructed tuple into constituents
    let customer, amount = purchases

    if amount > 100M then 
        { customer with IsVip = true }
    else
        customer



//        Add a function called “getPurchases” to Module1/Application/Functions.fs that
// Receives a customer as parameter
// Returns a tuple with the customer and its purchases, following these rules:
//o If customer.Id is divisible by 2, return purchases = 120M
//o If customer.Id is not divisible by 2, return purchases = 80M

//Remarks: No tuple naming as with C# 7.0 ValueTuples?
let getPurchases customer =
    if customer.Id % 2 = 0 then
        (customer, 120M)
    else
        (customer, 80M)
