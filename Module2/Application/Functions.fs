module Functions

open Types

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

//    1.1. Add a function called “increaseCredit” to Module2/Application/Functions.fs that
// Receives the condition (function) to evaluate as first parameter
// Receives the customer as second parameter
// Returns a customer with extra credit, following these rules
//o If the result of evaluating the condition with the customer is true, return an additional 100M of
//credit
//o If the result of the condition evaluation is false, return an additional 50M of credit

let increaseCredit predicate customer =
    if predicate customer then
        { customer with Credit = customer.Credit + 100M }
    else
        { customer with Credit = customer.Credit + 50M }

// Create a function called “increaseCreditUsingVip” in Module2/Application/Functions.fs by partially applying
//the “(fun c -> c.IsVip)” lambda as condition to the increaseCredit function:

let increaseCreditUsingVip = 
    increaseCredit (fun c -> c.IsVip )


//    Create a function called “upgradeCustomer” in Module2/Application/Functions.fs that
// Receives a customer as parameter
// Calls getPurchases with the customer and assigns the result to a customerWithPurchases value
// Then it calls tryPromoteToVip passing customerWithPurchases and assigns the result to a
//promotedCustomer value
// Then it calls increaseCreditUsingVip with promotedCustomer and assigns the result to an
//upgradedCustomer value
// Returns the upgradedCustomer value

let upgradeCustomerWithNoPipes customer =
    let customerWithPurchases = getPurchases customer
    let promotedCustomer = tryPromoteToVip customerWithPurchases
    let upgradedCustomer = increaseCreditUsingVip promotedCustomer
    upgradedCustomer

let upgradeCustomerWithPipes customer =
    customer     
    |> getPurchases
    |> tryPromoteToVip
    |> increaseCreditUsingVip

    //Now using function composition
let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip
    
    