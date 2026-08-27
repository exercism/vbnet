Public Class ParallelLetterFrequencyTests
    <Fact>
    Public Sub No_texts()
        Dim texts = Array.Empty(Of String)()
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_text_with_one_letter()
        Dim texts = {"a"}
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"a"c, 1}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_text_with_multiple_letters()
        Dim texts = {"bbcccd"}
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"b"c, 2},
            {"c"c, 3},
            {"d"c, 1}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_texts_with_one_letter()
        Dim texts = {
            "e",
            "f"
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"e"c, 1},
            {"f"c, 1}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_texts_with_multiple_letters()
        Dim texts = {
            "ggh",
            "hhi"
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"g"c, 2},
            {"h"c, 3},
            {"i"c, 1}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_letter_casing()
        Dim texts = {
            "m",
            "M"
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"m"c, 2}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_whitespace()
        Dim texts = {
            "   ",
            vbTab,
            vbCrLf
        }
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_punctuation()
        Dim texts = {
            "!",
            "?",
            ";",
            ",",
            "."
        }
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_numbers()
        Dim texts = {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        }
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unicode_letters()
        Dim texts = {
            "本",
            "φ",
            "ほ",
            "ø"
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"本"c, 1},
            {"φ"c, 1},
            {"ほ"c, 1},
            {"ø"c, 1}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Combination_of_lower_and_uppercase_letters_punctuation_and_white_space()
        Dim texts = {"There, peeping among the cloud-wrack above a dark tower high up in the mountains, Sam saw a white star twinkle for a while. The beauty of it smote his heart, as he looked up out of the forsaken land, and hope returned to him. For like a shaft, clear and cold, the thought pierced him that in the end, the shadow was only a small and passing thing: there was light and high beauty forever beyond its reach."}
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"a"c, 32},
            {"b"c, 4},
            {"c"c, 6},
            {"d"c, 14},
            {"e"c, 37},
            {"f"c, 7},
            {"g"c, 8},
            {"h"c, 29},
            {"i"c, 19},
            {"k"c, 6},
            {"l"c, 12},
            {"m"c, 7},
            {"n"c, 19},
            {"o"c, 22},
            {"p"c, 7},
            {"r"c, 17},
            {"s"c, 16},
            {"t"c, 30},
            {"u"c, 9},
            {"v"c, 2},
            {"w"c, 9},
            {"y"c, 4}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_texts()
        Dim texts = {
            "I am a sick man.... I am a spiteful man. I am an unattractive man." & vbLf & "I believe my liver is diseased. However, I know nothing at all about my disease, and do not" & vbLf & "know for certain what ails me. I don't consult a doctor for it," & vbLf & "and never have, though I have a respect for medicine and doctors." & vbLf & "Besides, I am extremely superstitious, sufficiently so to respect medicine," & vbLf & "anyway (I am well-educated enough not to be superstitious, but I am superstitious)." & vbLf & "No, I refuse to consult a doctor from spite." & vbLf & "That you probably will not understand. Well, I understand it, though." & vbLf & "Of course, I can't explain who it is precisely that I am mortifying in this case by my spite:" & vbLf & "I am perfectly well aware that I cannot ""pay out"" the doctors by not consulting them;" & vbLf & "I know better than anyone that by all this I am only injuring myself and no one else." & vbLf & "But still, if I don't consult a doctor it is from spite." & vbLf & "My liver is bad, well - let it get worse!" & vbLf & "I have been going on like that for a long time - twenty years. Now I am forty." & vbLf & "I used to be in the government service, but am no longer." & vbLf & "I was a spiteful official. I was rude and took pleasure in being so." & vbLf & "I did not take bribes, you see, so I was bound to find a recompense in that, at least." & vbLf & "(A poor jest, but I will not scratch it out. I wrote it thinking it would sound very witty;" & vbLf & "but now that I have seen myself that I only wanted to show off in a despicable way -" & vbLf & "I will not scratch it out on purpose!) When petitioners used to come for" & vbLf & "information to the table at which I sat, I used to grind my teeth at them," & vbLf & "and felt intense enjoyment when I succeeded in making anybody unhappy." & vbLf & "I almost did succeed. For the most part they were all timid people - of course," & vbLf & "they were petitioners. But of the uppish ones there was one officer in particular" & vbLf & "I could not endure. He simply would not be humble, and clanked his sword in a disgusting way." & vbLf & "I carried on a feud with him for eighteen months over that sword. At last I got the better of him." & vbLf & "He left off clanking it. That happened in my youth, though. But do you know," & vbLf & "gentlemen, what was the chief point about my spite? Why, the whole point," & vbLf & "the real sting of it lay in the fact that continually, even in the moment of the acutest spleen," & vbLf & "I was inwardly conscious with shame that I was not only not a spiteful but not even an embittered man," & vbLf & "that I was simply scaring sparrows at random and amusing myself by it." & vbLf & "I might foam at the mouth, but bring me a doll to play with, give me a cup of tea with sugar in it," & vbLf & "and maybe I should be appeased. I might even be genuinely touched," & vbLf & "though probably I should grind my teeth at myself afterwards and lie awake at night with shame for" & vbLf & "months after. That was my way. I was lying when I said just now that I was a spiteful official." & vbLf & "I was lying from spite. I was simply amusing myself with the petitioners and with the officer," & vbLf & "and in reality I never could become spiteful. I was conscious every moment in myself of many," & vbLf & "very many elements absolutely opposite to that. I felt them positively swarming in me," & vbLf & "these opposite elements. I knew that they had been swarming in me all my life and craving some outlet from me," & vbLf & "but I would not let them, would not let them, purposely would not let them come out." & vbLf & "They tormented me till I was ashamed: they drove me to convulsions and - sickened me, at last," & vbLf & "how they sickened me!",
            "Gentlemen, I am joking, and I know myself that my jokes are not brilliant" & vbLf & ",but you know one can take everything as a joke. I am, perhaps, jesting against the grain." & vbLf & "Gentlemen, I am tormented by questions; answer them for me. You, for instance, want to cure men of their" & vbLf & "old habits and reform their will in accordance with science and good sense." & vbLf & "But how do you know, not only that it is possible, but also that it is" & vbLf & "desirable to reform man in that way? And what leads you to the conclusion that man's" & vbLf & "inclinations need reforming? In short, how do you know that such a reformation will be a benefit to man?" & vbLf & "And to go to the root of the matter, why are you so positively convinced that not to act against" & vbLf & "his real normal interests guaranteed by the conclusions of reason and arithmetic is certainly always" & vbLf & "advantageous for man and must always be a law for mankind? So far, you know," & vbLf & "this is only your supposition. It may be the law of logic, but not the law of humanity." & vbLf & "You think, gentlemen, perhaps that I am mad? Allow me to defend myself. I agree that man" & vbLf & "is pre-eminently a creative animal, predestined to strive consciously for an object and to engage in engineering -" & vbLf & "that is, incessantly and eternally to make new roads, wherever" & vbLf & "they may lead. But the reason why he wants sometimes to go off at a tangent may just be that he is" & vbLf & "predestined to make the road, and perhaps, too, that however stupid the ""direct""" & vbLf & "practical man may be, the thought sometimes will occur to him that the road almost always does lead" & vbLf & "somewhere, and that the destination it leads to is less important than the process" & vbLf & "of making it, and that the chief thing is to save the well-conducted child from despising engineering," & vbLf & "and so giving way to the fatal idleness, which, as we all know," & vbLf & "is the mother of all the vices. Man likes to make roads and to create, that is a fact beyond dispute." & vbLf & "But why has he such a passionate love for destruction and chaos also?" & vbLf & "Tell me that! But on that point I want to say a couple of words myself. May it not be that he loves" & vbLf & "chaos and destruction (there can be no disputing that he does sometimes love it)" & vbLf & "because he is instinctively afraid of attaining his object and completing the edifice he is constructing?" & vbLf & "Who knows, perhaps he only loves that edifice from a distance, and is by no means" & vbLf & "in love with it at close quarters; perhaps he only loves building it and does not want to live in it," & vbLf & "but will leave it, when completed, for the use of les animaux domestiques -" & vbLf & "such as the ants, the sheep, and so on. Now the ants have quite a different taste." & vbLf & "They have a marvellous edifice of that pattern which endures for ever - the ant-heap." & vbLf & "With the ant-heap the respectable race of ants began and with the ant-heap they will probably end," & vbLf & "which does the greatest credit to their perseverance and good sense. But man is a frivolous and" & vbLf & "incongruous creature, and perhaps, like a chess player, loves the process of the game, not the end of it." & vbLf & "And who knows (there is no saying with certainty), perhaps the only goal on earth" & vbLf & "to which mankind is striving lies in this incessant process of attaining, in other words," & vbLf & "in life itself, and not in the thing to be attained, which must always be expressed as a formula," & vbLf & "as positive as twice two makes four, and such positiveness is not life, gentlemen," & vbLf & "but is the beginning of death.",
            "But these are all golden dreams. Oh, tell me, who was it first announced," & vbLf & "who was it first proclaimed, that man only does nasty things because he does not know his own interests;" & vbLf & "and that if he were enlightened, if his eyes were opened to his real normal interests," & vbLf & "man would at once cease to do nasty things, would at once become good and noble because," & vbLf & "being enlightened and understanding his real advantage, he would see his own advantage in the" & vbLf & "good and nothing else, and we all know that not one man can, consciously, act against his own interests," & vbLf & "consequently, so to say, through necessity, he would begin doing good? Oh, the babe! Oh, the pure," & vbLf & "innocent child! Why, in the first place, when in all these thousands of years has there been a time" & vbLf & "when man has acted only from his own interest? What is to be done with the millions of facts that bear" & vbLf & "witness that men, consciously, that is fully understanding their real interests, have left them in the" & vbLf & "background and have rushed headlong on another path, to meet peril and danger," & vbLf & "compelled to this course by nobody and by nothing, but, as it were, simply disliking the beaten track," & vbLf & "and have obstinately, wilfully, struck out another difficult, absurd way, seeking it almost in the darkness." & vbLf & "So, I suppose, this obstinacy and perversity were pleasanter to them than any advantage...." & vbLf & "Advantage! What is advantage? And will you take it upon yourself to define with perfect accuracy in what the" & vbLf & "advantage of man consists? And what if it so happens that a man's advantage, sometimes, not only may," & vbLf & "but even must,  consist in his desiring in certain cases what is harmful to himself and not advantageous." & vbLf & "And if so, if there can be such a case, the whole principle falls into dust. What do you think -" & vbLf & "are there such cases? You laugh; laugh away, gentlemen, but only answer me: have man's advantages been" & vbLf & "reckoned up with perfect certainty? Are there not some which not only have not been included but cannot" & vbLf & "possibly be included under any classification? You see, you gentlemen have, to the best of my knowledge," & vbLf & "taken your whole register of human advantages from the averages of statistical figures and" & vbLf & "politico-economical formulas. Your advantages are prosperity, wealth, freedom, peace - and so on, and so on." & vbLf & "So that the man who should, for instance, go openly and knowingly in opposition to all that list would to your thinking," & vbLf & "and indeed mine, too, of course, be an obscurantist or an absolute madman: would not he? But, you know, this is" & vbLf & "what is surprising: why does it so happen that all these statisticians,  sages and lovers of humanity," & vbLf & "when they reckon up human advantages invariably leave out one? They don't even take it into their reckoning" & vbLf & "in the form in which it should be taken, and the whole reckoning depends upon that. It would be no greater matter," & vbLf & "they would simply have to take it, this advantage, and add it to the list. But the trouble is, that this strange" & vbLf & "advantage does not fall under any classification and is not in place in any list. I have a friend for instance ..." & vbLf & "Ech! gentlemen, but of course he is your friend, too; and indeed there is no one, no one to whom he is not a friend!",
            "Yes, but here I come to a stop! Gentlemen, you must excuse me for being over-philosophical;" & vbLf & "it's the result of forty years underground! Allow me to indulge my fancy. You see, gentlemen, reason is an excellent thing," & vbLf & "there's no disputing that, but reason is nothing but reason and satisfies only the rational side of man's nature," & vbLf & "while will is a manifestation of the whole life, that is, of the whole human life including reason and all the impulses." & vbLf & "And although our life, in this manifestation of it, is often worthless, yet it is life and not simply extracting square roots." & vbLf & "Here I, for instance, quite naturally want to live, in order to satisfy all my capacities for life, and not simply my capacity" & vbLf & "for reasoning, that is, not simply one twentieth of my capacity for life. What does reason know? Reason only knows what it has" & vbLf & "succeeded in learning (some things, perhaps, it will never learn; this is a poor comfort, but why not say so frankly?)" & vbLf & "and human nature acts as a whole, with everything that is in it, consciously or unconsciously, and, even it if goes wrong, it lives." & vbLf & "I suspect, gentlemen, that you are looking at me with compassion; you tell me again that an enlightened and developed man," & vbLf & "such, in short, as the future man will be, cannot consciously desire anything disadvantageous to himself, that that can be proved mathematically." & vbLf & "I thoroughly agree, it can - by mathematics. But I repeat for the hundredth time, there is one case, one only, when man may consciously, purposely," & vbLf & "desire what is injurious to himself, what is stupid, very stupid - simply in order to have the right to desire for himself even what is very stupid" & vbLf & "and not to be bound by an obligation to desire only what is sensible. Of course, this very stupid thing, this caprice of ours, may be in reality," & vbLf & "gentlemen, more advantageous for us than anything else on earth, especially in certain cases. And in particular it may be more advantageous than" & vbLf & "any advantage even when it does us obvious harm, and contradicts the soundest conclusions of our reason concerning our advantage -" & vbLf & "for in any circumstances it preserves for us what is most precious and most important - that is, our personality, our individuality." & vbLf & "Some, you see, maintain that this really is the most precious thing for mankind; choice can, of course, if it chooses, be in agreement" & vbLf & "with reason; and especially if this be not abused but kept within bounds. It is profitable and some- times even praiseworthy." & vbLf & "But very often, and even most often, choice is utterly and stubbornly opposed to reason ... and ... and ... do you know that that," & vbLf & "too, is profitable, sometimes even praiseworthy? Gentlemen, let us suppose that man is not stupid. (Indeed one cannot refuse to suppose that," & vbLf & "if only from the one consideration, that, if man is stupid, then who is wise?) But if he is not stupid, he is monstrously ungrateful!" & vbLf & "Phenomenally ungrateful. In fact, I believe that the best definition of man is the ungrateful biped. But that is not all, that is not his worst defect;" & vbLf & "his worst defect is his perpetual moral obliquity, perpetual - from the days of the Flood to the Schleswig-Holstein period."
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"a"c, 845},
            {"b"c, 155},
            {"c"c, 278},
            {"d"c, 359},
            {"e"c, 1143},
            {"f"c, 222},
            {"g"c, 187},
            {"h"c, 507},
            {"i"c, 791},
            {"j"c, 12},
            {"k"c, 67},
            {"l"c, 423},
            {"m"c, 288},
            {"n"c, 833},
            {"o"c, 791},
            {"p"c, 197},
            {"q"c, 8},
            {"r"c, 432},
            {"s"c, 700},
            {"t"c, 1043},
            {"u"c, 325},
            {"v"c, 111},
            {"w"c, 223},
            {"x"c, 7},
            {"y"c, 251}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Many_small_texts()
        Dim texts = {
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc",
            "abbccc"
        }
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"a"c, 50},
            {"b"c, 100},
            {"c"c, 150}
        }
        Assert.Equal(expected, ParallelLetterFrequency.Calculate(texts))
    End Sub
End Class
