using WebApplication1.IRepository;
using WebApplication1.ModelsDTO;
using System.Linq;
namespace WebApplication1.Repository
{
    public class LambdaExpressionExample : ILambdaExpressionExample
    {
        public async Task<MessageHelperRecord> LambdaExpressionExampleCheck(Tuple<long, string, string> information)
        {
            try
            {
                var NumberList = new List<long>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Func<long, long, long> sumOfEven = (total, current) => current % 2 == 0 ? total + current : total;

                var sum = NumberList.Aggregate(0L, sumOfEven);

                MessageHelperRecord responseNotEqual = new MessageHelperRecord(200, $"Sum is = {sum.ToString()}");
                return responseNotEqual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






        public delegate long SumOfElement(long total, long current);
        public long CalculationFunction(List<long> numbers, SumOfElement deligateFucntion)
        {
            Func<long, long, long> modifiedfunction = new Func<long, long, long>(deligateFucntion);
            var sum = numbers.Aggregate(0L, modifiedfunction);
            return sum;
        }
        public async Task<MessageHelperRecord> LambdaExpressionExampleCallBack(Tuple<long, string, string> information)
        {
            try
            {
                //long lambdaFunctionForCalculatingSum(long total, long current) { return current % 2 == 0 ? total + current : total; }
                long lambdaFunctionForCalculatingSum(long total, long current) => current % 2 == 0 ? total + current : total; 

                var NumberList = new List<long>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                SumOfElement SumOfEven = lambdaFunctionForCalculatingSum; //(total, current) => current % 2 == 0 ? total + current : total;
                SumOfElement SumOfOdd = (total, current) => current % 2 == 1 ? total + current : total;

                var sumEven = CalculationFunction(NumberList, SumOfEven);
                var sumOdd = CalculationFunction(NumberList, SumOfOdd);

                MessageHelperRecord responseNotEqual = new MessageHelperRecord(200, $"Sum of Even = {sumEven.ToString()} And sum of Odd = {sumOdd.ToString()}");
                return responseNotEqual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /*
        public void gradeCalculation()
        {
            long a = 65;
            if (a >= 80)
                Console.WriteLine("A+");
            else if (a >= 70)
                Console.WriteLine("A");
            else if (a >= 60)
                Console.WriteLine("A-");
            else if (a >= 50)
                Console.WriteLine("B");
            else if (a >= 40)
                Console.WriteLine("C");
            else if (a >= 34)
                Console.WriteLine("D");
            else
                Console.WriteLine("Failed");
            Console.WriteLine("Hello World");
        }
        */
        
        public async Task<MessageHelperRecord> DeligateInstateOfIfElse(long Number)
        {
            try
            {
                long a = Number;
                var gradeMapping = new Dictionary<long, Func<long,MessageHelperRecord>>
                                    {
                                        { 80, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for A+ because your number is {key}"); return newMessage; } },   
                                        { 70, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for A because your number is {key}"); return newMessage; } },
                                        { 60, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for A- because your number is {key}"); return newMessage; } },
                                        { 50, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for B because your number is {key}"); return newMessage; } },
                                        { 40, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for C because your number is {key}"); return newMessage; } },
                                        { 34, (key) => { var newMessage = new MessageHelperRecord( 200, $"Code call for D because your number is {key}"); return newMessage; } }
                                    };

                var grade = gradeMapping.FirstOrDefault(pair => a >= pair.Key);
                if (grade.Value == null)
                {
                    return new MessageHelperRecord(200, $"You Failed because your number is {Number}");
                }
                var response = grade.Value(a);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
