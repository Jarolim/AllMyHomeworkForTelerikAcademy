var QuestionParser = (function () {

    function parseShortAnswerQuestion(json) {
        if (!json) {
            throw "Invalid input! It cannot be null!"
        }

        if (!(json.constructor === {}.constructor)) {
            throw "The input must be a JSON object!";
        }

        var saQuestion = new QuizGame.ShortAnswerQuestion(json.task, json.answer, json.downLimit, json.upLimit);
        return saQuestion;
    }

    function parseMultipleChoiceQuestion(json) {
        if (!json) {
            throw "Invalid input! It cannot be null!"
        }

        if (!(json.constructor === {}.constructor)) {
            throw "The input must be a JSON object!";
        }

        var answers = [json.a, json.b, json.c, json.d];
        var mcQuestion = new QuizGame.MultipleChoiceQuestion(json.task, json.answer, answers);
        return mcQuestion;
    }

    return {
        parseShortAnswerQuestion: parseShortAnswerQuestion,
        parseMultipleChoiceQuestion: parseMultipleChoiceQuestion
    }
}());