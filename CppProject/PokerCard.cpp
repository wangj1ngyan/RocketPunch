#include "PokerCard.h"

PokerCard::PokerCard(Suit suit, Rank rank) : suit(suit), rank(rank) {}

std::string PokerCard::display() const {
    static std::map<Rank, std::string> rank_to_string = {
        {Rank::A, "A"}, {Rank::K, "K"}, {Rank::Q, "Q"}, {Rank::J, "J"}, {Rank::T, "T"},
        {Rank::_9, "9"}, {Rank::_8, "8"}, {Rank::_7, "7"}, {Rank::_6, "6"}, {Rank::_5, "5"},
        {Rank::_4, "4"}, {Rank::_3, "3"}, {Rank::_2, "2"}
    };

    static std::map<Suit, std::string> suit_to_string = {
        {Suit::Spade, "S"}, {Suit::Heart, "H"}, {Suit::Diamond, "D"}, {Suit::Club, "C"}
    };

    return suit_to_string[suit] + rank_to_string[rank];
}

bool PokerCard::isJoker() const { return false; }
bool PokerCard::isBigJoker() const { return false; }
Suit PokerCard::getSuit() const { return suit; }
Rank PokerCard::getRank() const { return rank; }
