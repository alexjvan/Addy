using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
    public enum NodeType
    {
        // ----- Lexer ----- \\
        // identifiers
        IdentifierNode,
        // keywords
        // -- statements
        IfKeywordNode,
        ElseKeywordNode,
		SwitchKeywordNode,
        // -- loops
        DoKeywordNode,
        ForKeywordNode,
        WhileKeywordNode,
        // -- data structures
        LetterKeywordNode,
        LogicKeywordNode,
        NumKeywordNode,
        TextKeywordNode,
        // operators
        AdditionToken,
        SubtractionToken,
        MultiplicationToken,
        DivisionToken,
		// equating
        EqualsToken,
        NotToken,
        LessThanToken,
        GreaterThanToken,
        // punctuation
        PeriodToken,
        CommaToken,
		ColonToken,
        SemiColonToken,
        QuestionToken,
        // -- encasings
        OpenParenthesisToken,
        CloseParenthesisToken,
        OpenBraceToken,
        CloseBraceToken,
        OpenBracketToken,
        CloseBracketToken,
        // values
        LetterNode,
        LogicNode,
        NumNode,
        TextNode
    }
}
