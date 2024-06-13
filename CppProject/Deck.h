#ifndef DECK_H
#define DECK_H

#include <vector>
#include "Card.h"
#include "PokerCard.h"
#include "JokerCard.h"

class Deck {
private:
    std::vector<Card*> cards;

public:
    Deck();
    ~Deck();
    void shuffle();
    std::vector<Card*> getCards() const;
};

#endif // DECK_H
