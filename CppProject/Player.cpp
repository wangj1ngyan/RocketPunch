#include "Player.h"

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
