using Quiz;

const int MaxCountOfAttempts = 3;
const int QuestionsCount = 3;

List<string> CorrectAnswers =
        [
            "Good Job",
            "Well done",
            "Correct",
            "That's right"
        ];

List<Question> questions = GetQuestions();
Console.WriteLine($"Welcome to Quiz. There'll be {QuestionsCount} questions. Try to answer them");

for (int i = 1; i <= QuestionsCount; i++)
{
    Question randomQuestion = GetRandomQuestion(questions);
    AskQuestion(randomQuestion.QuestionText, i);
    var attempsRemain = MaxCountOfAttempts;
    bool isAnswered = false;

    while (attempsRemain > 0 && !isAnswered)
    {
        attempsRemain--;
        string userAnswer = Console.ReadLine();
        isAnswered = CheckAnswer(randomQuestion, userAnswer, attempsRemain);
    }
}
Console.WriteLine("GAME OVER");

static void AskQuestion(string question, int number)
{
    Console.WriteLine($"Question #{number}:");
    Console.WriteLine(question);
}

bool CheckAnswer(Question randomQuestion, string userAnswer, int attempsRemain)
{
    if (userAnswer == randomQuestion.Answer)
    {
        ConsoleWritePositiveAnswer();
        return true;

    }
    else
    {
        if (attempsRemain > 0)
        {
            Console.WriteLine($"Wrong, try again.{Environment.NewLine}Attemps left:{attempsRemain} ");
        }
        else
        {
            Console.WriteLine($"Wrong");
        }
    }
    return false;
}

static List<Question> GetQuestions()
{
    return new List<Question>
{
    new Question("How many continents are there on Earth?", "7"),
    new Question("How many hours are in a day?", "24"),
    new Question("How many minutes are in an hour?", "60")
};
}



static Question GetRandomQuestion(List<Question> questions)
{
    Random random = new();
    int randomIndex = random.Next(questions.Count);
    Question randomQuestion = questions[randomIndex];
    return randomQuestion;
}

void ConsoleWritePositiveAnswer()
{
    var correctAnswer = GetRandomAnswer();
    Console.WriteLine(correctAnswer);
}

string GetRandomAnswer()
{
    Random random = new();
    int index = random.Next(CorrectAnswers.Count); 
    string randomItem = CorrectAnswers[index];
    return randomItem;
}
