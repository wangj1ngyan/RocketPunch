#ifndef CARD_H
#define CARD_H

#include <string>
#include "Suit.h"
#include "Rank.h"

class Card {
public:
    virtual std::string display() const = 0;
    virtual ~Card() = default;
    virtual bool isJoker() const = 0;
    virtual bool isBigJoker() const = 0;
    virtual Suit getSuit() const = 0;
    virtual Rank getRank() const = 0;
};

#endif // CARD_H
