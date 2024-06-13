#ifndef POKERCARD_H
#define POKERCARD_H

#include "Card.h"
#include <map>

class PokerCard : public Card {
public:
    Suit suit;
    Rank rank;

    PokerCard(Suit suit, Rank rank);
    std::string display() const override;
    bool isJoker() const override;
    bool isBigJoker() const override;
    Suit getSuit() const override;
    Rank getRank() const override;
};

#endif // POKERCARD_H
