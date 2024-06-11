local Card = {}
Card.__index = Card

---@alias Suit "Spade" | "Heart" | "Diamond" | "Club" | "None"
---@alias Rank "A" | "K" | "Q" | "J" | "T" | "9" | "8" | "7" | "6" | "5" | "4" | "3" | "2" | "BJ" | "LJ"

---@class Card
function Card:new(suit, rank)
    local instance = {
        suit = suit,
        rank = rank,
    }
    setmetatable(instance, Card)
    return instance
end

function Card:display()
    return ""
end

function Card:isJoker()
    return false
end

function Card:isBigJoker()
    return false
end

function Card:getSuit()
    return self.suit
end

function Card:getRank()
    return self.rank
end

return Card
