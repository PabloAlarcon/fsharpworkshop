#load "Types.fs"
#load "Functions.fs"

open Types
open Functions

let customer = { Id = 1; IsVip = false; Credit = 10M }

let purchases = (customer, 101M)
let vipCustomer = tryPromoteToVip purchases

let calculatedPurchases = getPurchases customer

//1.3. Execute both functions (increaseCredit and increaseCreditUsingVip) in the F# Interactive and test the latter in
//Module2/Application/Try.fsx using the existing customer.

let increasedCreditForVip = increaseCreditUsingVip customer

let increasedCreditForActualVip = increaseCreditUsingVip vipCustomer