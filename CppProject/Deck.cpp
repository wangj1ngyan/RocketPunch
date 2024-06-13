#include "Deck.h"
#include <random>
#include <algorithm>
#include <ctime>

Deck::Deck() {
    std::vector<Suit> suits = {Suit::Spade, Suit::Heart, Suit::Diamond, Suit::Club};
    std::vector<Rank> ranks = {
        Rank::A, Rank::K, Rank::Q, Rank::J, Rank::T, Rank::_9, Rank::_8, Rank::_7,
        Rank::_6, Rank::_5, Rank::_4, Rank::_3, Rank::_2
    };

    // Initialize the deck with 52 cards
    for (const auto& suit : suits) {
        for (const auto& rank : ranks) {
            cards.push_back(new PokerCard(suit, rank));
        }
    }

    // Add Jokers
    cards.push_back(new JokerCard(true));  // Big Joker
    cards.push_back(new JokerCard(false)); // Little Joker
}

Deck::~Deck() {
    for (auto card : cards) {
        delete card;
    }
}

void Deck::shuffle() {
    // Use current time as seed for random generator
    std::mt19937 rng(static_cast<unsigned int>(std::time(nullptr)));
    std::shuffle(cards.begin(), cards.end(), rng);
}

std::vector<Card*> Deck::getCards() const {
    return cards;
}
