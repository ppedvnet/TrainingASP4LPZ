var blackjack = blackjack || {};

blackjack.game = function(){
    function createDeck(){
        let values = ['Ace', 'King', 'Queen', 'Jack', 'Ten', 'Nine', 'Eight', 'Seven', 'Six', 'Five', 'Four', 'Three', 'Two'];
        let suits = ['Hearts', 'Clubs', 'Diamonds', 'Spades'];
        let deck = [];

        for (let suitIdx = 0; suitIdx < suits.length; suitIdx++){
            for(let valueIdx = 0; valueIdx < values.length; valueIdx++){
                let card = new blackjack.card(
                    suits[suitIdx],
                    values[valueIdx]
                );
                deck.push(card);
            }
        }
        return deck;
    }

    function getNextCard(){
        let idx = Math.floor(Math.random()*(deck.length-1));
        var card = deck[idx];
        deck.splice(idx, 1);
        return card;
    }

    function getCardString(card){
        return card.value + ' of ' + card.suit;
    }

    let deck = createDeck();

    return {
        deck : deck,
        getCardString: getCardString,
        getNextCard: getNextCard
    }
}