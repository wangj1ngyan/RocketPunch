#include "PokerShuffle.h"

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
    std::shuffle(cards.begin(), cards.end(), std::mt19937{std::random_device{}()});
}

std::vector<Card*> Deck::getCards() const {
    return cards;
}

void Player::receive_cards(const std::vector<Card*>& cards) {
    hand.insert(hand.end(), cards.begin(), cards.end());
}

void Player::sort_hand() {
    auto card_comparison = [](Card* x, Card* y) {
        if (x->isJoker() && y->isJoker()) {
            return y->isBigJoker() < x->isBigJoker();  // Big Joker first
        }
        if (x->isJoker()) {
            return true; 
        }
        if (y->isJoker()) {
            return false;
        }
        if (x->getSuit() != y->getSuit()) {
            return x->getSuit() < y->getSuit();  // Suit order: Spade, Heart, Diamond, Club
        }
        return x->getRank() < y->getRank();  // Rank in descending order
    };

    std::sort(hand.begin(), hand.end(), card_comparison);
}

std::string Player::display_hand() const {
    std::string result;
    for (const auto& card : hand) {
        result += card->display() + " ";
    }
    return result;
}
