#ifndef JOKERCARD_H
#define JOKERCARD_H

#include "Card.h"

class JokerCard : public Card {
public:
    bool isBigJokerFlag;

    JokerCard(bool isBigJoker);
    std::string display() const override;
    bool isJoker() const override;
    bool isBigJoker() const override;
    Suit getSuit() const override;
    Rank getRank() const override;
};

#endif // JOKERCARD_H
