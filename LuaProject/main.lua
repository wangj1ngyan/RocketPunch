package.path = package.path .. ";./?.lua"

local Deck = require("Deck")
local Player = require("Player")

local deck = Deck:new()
deck:shuffle()

local playerCount = 3
local players = {}

for i = 1, playerCount do
    players[i] = Player:new()
end

local shuffledCards = deck:getCards()
for i = 1, #shuffledCards do
    players[(i - 1) % playerCount + 1]:receive_cards({shuffledCards[i]})
end

for i = 1, playerCount do
    players[i]:sort_hand()
    print("Player " .. i .. ": " .. players[i]:display_hand())
end
