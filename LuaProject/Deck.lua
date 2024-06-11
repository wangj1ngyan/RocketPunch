local PokerCard = require("PokerCard")
local JokerCard = require("JokerCard")

---@class Deck
local Deck = {}
Deck.__index = Deck

---@return Deck
function Deck:new()
    local instance = {
        cards = {}
    }
    setmetatable(instance, Deck)

    local suits = { "Spade", "Heart", "Diamond", "Club" }
    local ranks = { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" }

    for _, suit in ipairs(suits) do
        for _, rank in ipairs(ranks) do
            table.insert(instance.cards, PokerCard:new(suit, rank))
        end
    end

    table.insert(instance.cards, JokerCard:new(true))  -- Big Joker
    table.insert(instance.cards, JokerCard:new(false)) -- Little Joker

    return instance
end

function Deck:shuffle()
    local cards = self.cards
    for i = #cards, 2, -1 do
        local j = math.random(i)
        cards[i], cards[j] = cards[j], cards[i]
    end
end

function Deck:getCards()
    return self.cards
end

return Deck
