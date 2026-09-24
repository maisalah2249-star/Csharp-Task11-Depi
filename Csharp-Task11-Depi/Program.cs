namespace Csharp_Task11_Depi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================
            // SECTION 01
            // =========================================

            List<Book> books = new List<Book>
            {
                new Book(
                    "111",
                    "C# Basics",
                    new string[] { "Ahmed", "Ali" },
                    new DateTime(2024, 1, 10),
                    300
                ),

                new Book(
                    "222",
                    "C# Advanced",
                    new string[] { "Sara" },
                    new DateTime(2025, 5, 20),
                    500
                )
            };

            Console.WriteLine("===== SECTION 01 =====");

            // User Defined Delegate
            Console.WriteLine("\nBook Titles:");

            LibraryEngine.ProcessBooks(
                books,
                BookFunctions.GetTitle
            );

            // Func
            Console.WriteLine("\nBook Authors:");

            LibraryEngine.ProcessBooksFunc(
                books,
                BookFunctions.GetAuthors
            );

            // Anonymous Method
            Console.WriteLine("\nBook ISBN:");

            LibraryEngine.ProcessBooksFunc(
                books,
                delegate (Book B)
                {
                    return B.ISBN;
                }
            );

            // Lambda
            Console.WriteLine("\nPublication Dates:");

            LibraryEngine.ProcessBooksFunc(
                books,
                B => B.PublicationDate.ToShortDateString()
            );


            // =========================================
            // SECTION 02
            // =========================================

            Console.WriteLine("\n===== SECTION 02 =====");

            Order order = new Order
            {
                Id = 1,
                CustomerName = "Mai",
                Price = 100,
                Quantity = 5
            };

            OrderService orderService = new OrderService();


            // =========================================
            // PART 1 - USER DEFINED DELEGATE
            // =========================================

            Console.WriteLine("\n--- Part 1 ---");

            decimal total =
                orderService.CalculateOrderPrice(
                    order,
                    CalculateTotal
                );

            Console.WriteLine(
                $"Total Price = {total}"
            );


            decimal discountedTotal =
                orderService.CalculateOrderPrice(
                    order,
                    CalculateTotalWithDiscount
                );

            Console.WriteLine(
                $"Discounted Price = {discountedTotal}"
            );


            // =========================================
            // PART 2 - FUNC
            // =========================================

            Console.WriteLine("\n--- Part 2 ---");

            decimal normalPrice =
                orderService.CalculateOrderPriceWithFunc(
                    order,
                    x => x.Price * x.Quantity
                );

            Console.WriteLine(
                $"Normal Price = {normalPrice}"
            );


            decimal tenPercentDiscount =
                orderService.CalculateOrderPriceWithFunc(
                    order,
                    x => (x.Price * x.Quantity) * 0.90m
                );

            Console.WriteLine(
                $"10% Discount Price = {tenPercentDiscount}"
            );


            // =========================================
            // PART 3 - PREDICATE
            // =========================================

            Console.WriteLine("\n--- Part 3 ---");

            bool validQuantity =
                orderService.ValidateOrder(
                    order,
                    x => x.Quantity > 0
                );

            Console.WriteLine(
                $"Quantity Valid = {validQuantity}"
            );


            bool validPrice =
                orderService.ValidateOrder(
                    order,
                    x => x.Price > 0
                );

            Console.WriteLine(
                $"Price Valid = {validPrice}"
            );


            bool validCustomer =
                orderService.ValidateOrder(
                    order,
                    x => !string.IsNullOrWhiteSpace(
                        x.CustomerName
                    )
                );

            Console.WriteLine(
                $"Customer Valid = {validCustomer}"
            );


            // =========================================
            // PART 4 - ACTION
            // =========================================

            Console.WriteLine("\n--- Part 4 ---");

            Action<Order> printOrder = x =>
            {
                Console.WriteLine(
                    $"Order Id: {x.Id}"
                );

                Console.WriteLine(
                    $"Customer: {x.CustomerName}"
                );

                Console.WriteLine(
                    $"Price: {x.Price}"
                );

                Console.WriteLine(
                    $"Quantity: {x.Quantity}"
                );
            };


            Action<Order> sendConfirmation = x =>
            {
                Console.WriteLine(
                    $"Confirmation sent to {x.CustomerName}"
                );
            };


            Action<Order> auditOrder = x =>
            {
                Console.WriteLine(
                    $"Audit: Order {x.Id} processed."
                );
            };


            // Multicast Delegate

            Action<Order> allActions =
                printOrder +
                sendConfirmation +
                auditOrder;


            orderService.ProcessOrder(
                order,
                allActions
            );


            // =========================================
            // PART 5 - EVENT
            // =========================================

            Console.WriteLine("\n--- Part 5 ---");

            orderService.OrderProcessed += Handler1;

            orderService.OrderProcessed += Handler2;

            orderService.OrderProcessed += Handler3;


            orderService.ProcessOrderWithEvent(order);


            // =========================================
            // PART 6 - UNSUBSCRIBE
            // =========================================

            Console.WriteLine("\n--- Part 6 ---");

            orderService.OrderProcessed -= Handler1;


            Console.WriteLine(
                "After removing Handler1:"
            );


            orderService.ProcessOrderWithEvent(order);


            Console.WriteLine("\nProgram Finished.");
        }


        // =========================================
        // PART 1 METHODS
        // =========================================

        static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }


        static decimal CalculateTotalWithDiscount(Order order)
        {
            decimal total =
                order.Price * order.Quantity;

            return total - 20;
        }


        // =========================================
        // EVENT HANDLERS
        // =========================================

        static void Handler1(Order order)
        {
            Console.WriteLine(
                $"Handler1: Order {order.Id} completed."
            );
        }


        static void Handler2(Order order)
        {
            Console.WriteLine(
                $"Handler2: Notification sent."
            );
        }


        static void Handler3(Order order)
        {
            Console.WriteLine(
                $"Handler3: Audit message written."
            );
        }
    }
}
    
