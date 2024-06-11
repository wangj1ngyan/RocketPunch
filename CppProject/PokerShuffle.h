#ifndef POKERSHUFFLE_H
#define POKERSHUFFLE_H

#include <iostream>
#include <vector>
#include <algorithm>
#include <random>
#include <ctime>
#include <map>

enum class Suit {
    Spade,
    Heart,
    Diamond,
    Club,
    None
};

enum class Rank {
    A,
    K,
    Q,
    J,
    T,
    _9,
    _8,
    _7,
    _6,
    _5,
    _4,
    _3,
    _2,
    BJ,
    LJ
};

class Card {
public:
    virtual std::string display() const = 0;
    virtual ~Card() = default;
    virtual bool isJoker() const = 0;
    virtual bool isBigJoker() const = 0;
    virtual Suit getSuit() const = 0;
    virtual Rank getRank() const = 0;
};

class PokerCard : public Card {
public:
    Suit suit;
    Rank rank;

    PokerCard(Suit suit, Rank rank) : suit(suit), rank(rank) {}

    std::string display() const override {
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

    bool isJoker() const override { return false; }
    bool isBigJoker() const override { return false; }
    Suit getSuit() const override { return suit; }
    Rank getRank() const override { return rank; }
};

class JokerCard : public Card {
public:
    bool isBigJokerFlag;

    JokerCard(bool isBigJoker) : isBigJokerFlag(isBigJoker) {}

    std::string display() const override {
        return isBigJokerFlag ? "BJ" : "LJ";
    }

    bool isJoker() const override { return true; }
    bool isBigJoker() const override { return isBigJokerFlag; }
    Suit getSuit() const override { return Suit::None; }
    Rank getRank() const override { return isBigJokerFlag ? Rank::BJ : Rank::LJ; }
};

class Deck {
private:
    std::vector<Card*> cards;

public:
    Deck();
    ~Deck();
    void shuffle();
    std::vector<Card*> getCards() const;
};

class Player {
public:
    std::vector<Card*> hand;

    void receive_cards(const std::vector<Card*>& cards);
    void sort_hand();
    std::string display_hand() const;
};

#endif // POKERSHUFFLE_H
