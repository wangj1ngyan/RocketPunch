#include "JokerCard.h"

JokerCard::JokerCard(bool isBigJoker) : isBigJokerFlag(isBigJoker) {}

std::string JokerCard::display() const {
    return isBigJokerFlag ? "BJ" : "LJ";
}

bool JokerCard::isJoker() const { return true; }
bool JokerCard::isBigJoker() const { return isBigJokerFlag; }
Suit JokerCard::getSuit() const { return Suit::None; }
Rank JokerCard::getRank() const { return isBigJokerFlag ? Rank::BJ : Rank::LJ; }
