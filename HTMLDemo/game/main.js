var blackjack = blackjack || {};

(function(){

    const newGameButton = document.getElementById('new-game-button');
    const textArea = document.getElementById('text-area');

    let playerCards, playerCards2;
    let game = new blackjack.game();

    newGameButton.addEventListener('click', function(){
        var deck = game.deck;
        playerCards = [game.getNextCard(), game.getNextCard()];
        playerCards2 = [game.getNextCard(), game.getNextCard()];

        textArea.innerText = "Started...";
        showStatus();
    });

    function showStatus(){
        textArea.innerText = "Welcome to Blackjack!";

        var cards = document.getElementsByClassName("card-value");
        
        cards[0].innerText = game.getCardString(playerCards[0]);
        cards[1].innerText = game.getCardString(playerCards[0]);
        cards[2].innerText = game.getCardString(playerCards2[1]);
        cards[3].innerText = game.getCardString(playerCards2[1]);

        cards[4].innerText = game.getCardString(playerCards[0]);
        cards[5].innerText = game.getCardString(playerCards[0]);
        cards[6].innerText = game.getCardString(playerCards2[1]);
        cards[7].innerText = game.getCardString(playerCards2[1]);

        console.log(" " + game.getCardString(playerCards[0]));
        console.log(" " + game.getCardString(playerCards[1]));
        console.log(" " + game.getCardString(playerCards2[0]));
        console.log(" " + game.getCardString(playerCards2[1]));
    }
})();