#include <iostream>
#include <vector>
#include "Deck.h"
#include "Player.h"

int main() {
    Deck deck;
    deck.shuffle();

    int playerCount = 3;
    std::vector<Player> players(playerCount);

    std::vector<Card*> shuffledCards = deck.getCards();

    for (int i = 0; i < shuffledCards.size(); ++i) {
        players[i % playerCount].receive_cards({shuffledCards[i]});
    }

    for (int i = 0; i < playerCount; ++i) {
        players[i].sort_hand();
    }

    for (int i = 0; i < playerCount; ++i) {
        std::cout << "Player " << (i + 1) << ": " << players[i].display_hand() << std::endl;
    }

    return 0;
}
