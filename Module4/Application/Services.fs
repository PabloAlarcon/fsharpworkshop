namespace Services

//Step 2: Create a CustomerService class with an UpgradeCustomer method
//2.1. Open Module4/Application/Services.fs and add a “CustomerService” class with an UpgradeCustomers method
//that:
// Receives the id of the customer
// Finds the customer using Function.getCustomer
// And then calls Functions.upgradeCustomer

//Remarks qualifying Module/Namespace -> either open it or qualify
open Functions

type CustomerService() =
    member this.UpgradeCustomer customerId =
        getCustomer customerId
        |> upgradeCustomer
        //let customer = Functions.getCustomer customerId

    member this.GetCustomerInfo customer =
        let isAdult = isAdult customer
        let alert = getAlert customer

        sprintf "Id: %i, IsVip: %b, Credit: %.2f, IsAdult: %b, Alert: %s" customer.Id customer.IsVip customer.Credit isAdult alert


//Step 3: Add a GetCustomerInfo method to the CustomerService class
//3.1. Open Module4/Application/Services.fs and add a method called “GetCustomerInfo” that:
// Receives a customer as parameter
// Calculates whether the customer is adult or not using the Functions.isAdult function
// Gets the alert using the Functions.getAlert function
// Returns a string with the format "Id: [Id], IsVip: [IsVip], Credit: [Credit], IsAdult: [IsAdult], Alert: [Alert]"